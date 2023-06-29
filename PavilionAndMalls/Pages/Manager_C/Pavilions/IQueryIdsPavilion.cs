namespace PavilionAndMalls.Pages.Manager_C.Pavilions
{
    public interface IQueryIdsPavilion
    {
        void AddPavilion(string Floor, string CodePavilion, string Area, string Status, string VAF, string MQC);
        void UpdatePavilion(string Floor, string CodePavilion, string Area, string Status, string VAF, string MQC);
    }
}
