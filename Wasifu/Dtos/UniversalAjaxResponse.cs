namespace Wasifu.Dtos
{
    public class AjaxResponse
    {
        public object? data { get; set; } = null;
        public int status { get; set; }
        public bool success { get; set; }
        public string? Message { get; set; }
        public string? exeption { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public AjaxResponse(string? _message = null, bool _success = true)
        {
            success = _success;
            if (string.IsNullOrEmpty(_message))
            {
                Message = _message;
            }

        }
    }
}
