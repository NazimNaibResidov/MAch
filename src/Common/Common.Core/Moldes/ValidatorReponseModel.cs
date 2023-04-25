using System.Text.Json.Serialization;

namespace Common.Core.Moldes
{
    public class ValidatorReponseModel
    {
        public ValidatorReponseModel(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public ValidatorReponseModel(string message) : this(new List<string> { message })
        {
        }

        public IEnumerable<string> Errors { get; set; }

        [JsonIgnore]
        public string FlattenErros => Errors != null
            ? string.Join(Environment.NewLine, Errors) : string.Empty;
    }
}
