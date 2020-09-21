﻿using Microsoft.Extensions.Options;

namespace Umbraco.Core.Configuration.Models.Validation
{
    public class ModelsBuilderSettingsValidator : ConfigurationValidatorBase, IValidateOptions<ModelsBuilderSettings>
    {
        public ValidateOptionsResult Validate(string name, ModelsBuilderSettings options)
        {
            if (!ValidateModelsMode(options.ModelsMode, out var message))
            {
                return ValidateOptionsResult.Fail(message);
            }

            return ValidateOptionsResult.Success;
        }

        private bool ValidateModelsMode(string value, out string message)
        {
            return ValidateStringIsOneOfEnumValues($"{Constants.Configuration.ConfigModelsBuilder}:{nameof(ModelsBuilderSettings.ModelsMode)}", value, typeof(ModelsMode), out message);
        }
    }
}
