namespace PostApp.Models
{
	public class BaseErrorResponse
	{
		public string ErrorMessage { get; set; }

		public string StackTrace { get; set; }
	}
}
