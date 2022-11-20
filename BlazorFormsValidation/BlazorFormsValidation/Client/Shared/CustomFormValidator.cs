using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorFormsValidation.Client.Shared
{
    public class CustomFormValidator : ComponentBase
    {
        private ValidationMessageStore? validationMessageStore;

        [CascadingParameter]
        private EditContext? CurrentEditContext { get; set; }

        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(CustomFormValidator)} requires a cascading parameter of type {nameof(EditContext)}.");
            }

            validationMessageStore = new ValidationMessageStore(CurrentEditContext);

            CurrentEditContext.OnValidationRequested += (s, e) =>
                validationMessageStore.Clear();
            CurrentEditContext.OnFieldChanged += (s, e) =>
                validationMessageStore.Clear(e.FieldIdentifier);
        }

        public void DisplayFormErrors(Dictionary<string, List<string>> errors)
        {
            if (CurrentEditContext is not null)
            {
                foreach (var err in errors)
                {
                    validationMessageStore?.Add(CurrentEditContext.Field(err.Key), err.Value);
                }
            }

            CurrentEditContext?.NotifyValidationStateChanged();
        }

        public void ClearFormErrors()
        {
            validationMessageStore?.Clear();
            CurrentEditContext?.NotifyValidationStateChanged();
        }
    }
}
