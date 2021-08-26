using System.ComponentModel.DataAnnotations;


namespace PS.Domain.Enums
{
    public enum StatusEnum
    {
        [Display(Name = "SUCCESS")]
        Success,
        [Display(Name = "FAILED")]
        Failed,
        [Display(Name = "CLOSED")]
        Closed,
    }
}
