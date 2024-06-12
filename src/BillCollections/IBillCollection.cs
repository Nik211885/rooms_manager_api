namespace src.BillCollections
{
    public interface IBillCollection
    {
        //Return Description Customer's Bill
        string GetInformationBill();
        //Calculate Bill details
        decimal CalculateService();
    }
}
