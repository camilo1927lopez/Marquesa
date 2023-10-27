namespace MarquesaReplenish.Web.Auth
{
    public interface IRecoverPassword
    {
        Task RecoverAsync(string token);
    }
}
