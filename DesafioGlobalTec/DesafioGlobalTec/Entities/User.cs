namespace DesafioGlobalTec.Entities
{
    //Classe do objeto Usuario login, requisitor do Token
    public class User
    {
        public string UserID { get; set; }
        public string AccessKey { get; set; }
    }

    //Classe parametros do token de retorno
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}