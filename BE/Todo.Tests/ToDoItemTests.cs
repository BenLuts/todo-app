using System.Net;
using System.Net.Http.Json;
using Todo.Tests.APIResponse;
using static Todo.Tests.TestContainerFixture;

namespace Todo.Tests;

public class TodoItemTests
{
    public class Read : TestBase
    {
        private const string DefaultEndPoint = "todo";
        private readonly Guid _existingGuid = new("d4e059e1-64e0-4da4-9e4a-b25c308f33e7");
        private readonly Guid _existingUserId = new("3f684fa9-b4c7-4498-88c7-7d86951359d6");

        public Read(TestContainerFixture testFixture) : base(testFixture)
        {
        }

        [Fact]
        public async Task An_existing_to_do_item_with_a_unique_ID_should_return_the_correct_item_from_the_datastore()
        {
            var existingItem = GetExistingTodoItem();
            var apiClient = GetApiClient();

            var apiResult = await apiClient.GetAsync($"{DefaultEndPoint}/{existingItem.Data.Id}");

            apiResult.Should().BeSuccessful();
            (await apiResult.Content.ReadFromJsonAsync<GenericTestResponse<TodoItemTest>>()).Should().BeEquivalentTo(existingItem);
        }

        [Fact]
        public async Task Items_that_are_assigned_to_a_specific_user_should_only_get_items_for_that_user_from_the_datastore()
        {
            var apiClient = GetApiClient();

            var apiResult = await apiClient.GetAsync($"{DefaultEndPoint}/assigned/tome");

            apiResult.Should().BeSuccessful();
            (await apiResult.Content.ReadFromJsonAsync<GenericTestResponse<TodoItemTest[]>>()).Data
                .Should()
                .NotBeEmpty()
                .And
                .AllSatisfy(todoItems => todoItems.AssignedTo.Exists(assignedUser => assignedUser.Id == _existingUserId));
        }

        [Fact]
        public async Task A_none_existing_to_do_item_with_a_unique_ID_should_return_nothing()
        {
            var apiClient = GetApiClient();

            var apiResult = await apiClient.GetAsync($"{DefaultEndPoint}/{Guid.Empty}");

            apiResult.Should().BeSuccessful();
            (await apiResult.Content.ReadFromJsonAsync<GenericTestResponse<TodoItemTest>>()).StatusCode.Should().Be((int)HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task An_exception_while_reading_should_be_handled_gracefully()
        {
            var apiClient = GetApiClient();

            var apiResult = await apiClient.GetAsync($"{DefaultEndPoint}/185d4571-172e-44a8-a5cb-b5334cf73c99");

            apiResult.Should().BeSuccessful();
            (await apiResult.Content.ReadFromJsonAsync<GenericTestResponse<TodoItemTest>>()).Should().BeEquivalentTo(GetGracefullError());
        }

        private GenericTestResponse<TodoItemTest> GetExistingTodoItem() => new() { Data = new() { Id = _existingGuid }, StatusCode = (int)HttpStatusCode.OK };
        private static GenericTestResponse<TodoItemTest> GetGracefullError() => new() { StatusCode = (int)HttpStatusCode.InternalServerError };
    }
}
