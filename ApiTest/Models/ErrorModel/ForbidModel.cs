namespace ApiTest.Models.ErrorModel
{
    public class ErrorClass
    {
        public int Statuscode { get; set; }
        public string Massage { get; set; }
        public ErrorClass(int code, string massage)
        {
            Statuscode = code;
            Massage = massage;
        }
    }
}
