namespace FDMC.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ICatService
    {
        Cat FindCatById(int id);

        List<Cat> GetCatList();

        void AddCat(Cat newCat);
    }
}