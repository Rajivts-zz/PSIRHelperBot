using System;
using Microsoft.Bot.Builder.FormFlow;

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    [Prompt("Hi there! Which {&} do you want to connect to?")]
    public string Environment { get; set; }

    [Prompt("What's the {&} number that you wish to re-process?")]
    public string Package { get; set; }

    public static IForm<BasicForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<BasicForm>().Build();
    }

    public static IFormDialog<BasicForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
