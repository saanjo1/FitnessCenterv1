namespace FitnessCenter.Web.ViewModels
{
    public class UserChangePasswordVM
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
