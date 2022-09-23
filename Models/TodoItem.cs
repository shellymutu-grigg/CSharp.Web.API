using System.ComponentModel.DataAnnotations;
using System.Configuration;
using  System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using NuGet.Protocol;

namespace CSharp.Web.API.Models
{
	public class TodoItem : IValidatableObject
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public bool IsComplete { get; set; }

		//static Boolean IsADigitAndNotWhiteSpace(string toValidate)
		//{
		//	return toValidate.All(char.IsDigit);
		//}

		static Boolean IsOnlyAllowableCharacters(string toValidate)
		{
			Console.WriteLine("\n Regex check: " + Regex.IsMatch(toValidate, "^[a-zA-z0-9\\s\\d!@$%&()?]*$"));
			return Regex.IsMatch(toValidate, "^[a-zA-z0-9\\s\\d!@$%&()?]*$");
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();

			Console.WriteLine("Validate inputs: " + validationContext.ToJson());

			//Validator.TryValidateProperty(this.Id, new ValidationContext(this, null, null) { MemberName = "Id" },
			//	results);
			Validator.TryValidateProperty(this.Name, new ValidationContext(this, null, null) { MemberName = "Name" },
				results);
			Validator.TryValidateProperty(this.IsComplete, new ValidationContext(this, null, null) { MemberName = "IsComplete" },
				results);

			// Validate that the id entered is not null, whitespace or empty and is digits
			//if (!String.IsNullOrEmpty(Id.ToString()))
			//{
			//	if (IsADigitAndNotWhiteSpace(Id.ToString()))
			//	{
			//		Console.WriteLine("Id Is A Digit And Not White Space " + IsADigitAndNotWhiteSpace(Id.ToString()));
			//	}
			//	results.Add(new ValidationResult("Missing a todo item ID"));
			//}
			//else
			//{
			//	results.Add(new ValidationResult("You must enter a todo item ID to find"));
			//}

			// Validate that the name of the todo item is not null or empty and is only letters and digits
			if (!String.IsNullOrEmpty(Name))
			{
				if (IsOnlyAllowableCharacters(Name))
				{
					Console.WriteLine("Name Is Only Allowable Characters " + IsOnlyAllowableCharacters(Name));
				}
				else
				{
					results.Add(new ValidationResult("Please check the title of your todo task"));
				}
				
			}
			else
			{
				results.Add(new ValidationResult("You must enter a text value for your todo item"));
			}

			Console.WriteLine("End of validating inputs");
			Console.WriteLine("\n Results: " + results.ToJson() + "\n");
			return results;
		}
	}
}
