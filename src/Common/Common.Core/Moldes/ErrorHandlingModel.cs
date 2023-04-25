using System.Text.Json;

namespace Common.Core.Moldes
{
    public class ErrorHandlingModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
