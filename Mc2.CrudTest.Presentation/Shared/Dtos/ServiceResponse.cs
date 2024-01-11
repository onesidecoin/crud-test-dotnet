namespace Mc2.CrudTest.Presentation.Shared.Dtos
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
        }

        public ServiceResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsSuccessful =false;
        }

        public ServiceResponse(T data)
        {
            Data = data;
            IsSuccessful =true;
        }

        public T Data { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}
