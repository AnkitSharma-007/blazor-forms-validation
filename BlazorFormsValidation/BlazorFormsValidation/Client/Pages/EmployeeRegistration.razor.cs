using BlazorFormsValidation.Client.Shared;
using BlazorFormsValidation.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace BlazorFormsValidation.Client.Pages
{
    public class EmployeeRegistrationBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; } = default!;

        [Inject]
        ILogger<EmployeeRegistrationBase>? Logger { get; set; } = default!;

        protected Employee employee = new();

        protected CustomFormValidator customFormValidator = default!;
        protected bool isRegistrationSuccessful = false;

        protected async Task RegisterEmployee()
        {
            customFormValidator?.ClearFormErrors();
            isRegistrationSuccessful = false;
            try
            {
                var response = await Http.PostAsJsonAsync("api/Employee", employee);
                var errors = await response.Content.ReadFromJsonAsync<Dictionary<string, List<string>>>();

                if (response.StatusCode == HttpStatusCode.BadRequest && errors?.Count > 0)
                {
                    customFormValidator?.DisplayFormErrors(errors);
                    throw new HttpRequestException($"Validation failed. Status Code: {response.StatusCode}");
                }
                else
                {
                    isRegistrationSuccessful = true;
                    Logger?.LogInformation("The registration is successful");
                }
            }
            catch (Exception ex)
            {
                Logger?.LogError(ex.Message);
            }
        }
    }
}
