using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Desk.Helpers
{
    public class Validate
    {
        public bool ValidarObjecto<T>(T objecto)
        {
            try
            {
                List<string> ltsMensajes = new List<string>();
                IList<ValidationResult> errors = new List<ValidationResult>();

                if (!Validator.TryValidateObject(objecto!, new ValidationContext(objecto!), errors, true))
                    ltsMensajes.AddRange(errors.Select(t => $"* {t.ErrorMessage}"));

                foreach (var item in objecto!.GetType().GetProperties())
                {
                    if (new Type[] { typeof(int), typeof(double), typeof(decimal) }.Any(t => t == item.PropertyType) && item.Name.ToLower() != "id")
                    {
                        dynamic valor;
                        valor = Convert.ChangeType(item.GetValue(objecto), item.PropertyType)!;

                        string displayName = GetDisplayAttribute(objecto, item.Name);
                        if (string.IsNullOrEmpty(displayName))
                            displayName = item.Name;

                        if (valor < 1)
                            ltsMensajes.Add($"* El campo {displayName} es obligatorio.");
                    }
                }

                if (ltsMensajes.Count > 0)
                    throw new Exception(string.Join(Environment.NewLine, ltsMensajes));

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {nameof(ValidarObjecto)}:{Environment.NewLine}{ex.Message}");
            }
        }

        public string GetDisplayAttribute<T>(T objecto, string nameProperty)
        {
            try
            {
                string displayName = null!;
                CustomAttributeData displayAttribute = objecto!.GetType().GetProperty(nameProperty)!.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute")!;
                if (displayAttribute != null)
                    displayName = displayAttribute.NamedArguments.FirstOrDefault().TypedValue.Value!.ToString()!;

                return displayName;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {nameof(GetDisplayAttribute)}:{Environment.NewLine}{ex.Message}");
            }
        }
    }
}
