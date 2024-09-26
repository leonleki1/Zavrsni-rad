namespace WebApiPaulovnija.Service
   
{
using WebApiPaulovnija.Service;
using System.Collections.Generic;
    using WebApiPaulovnija.Controllers.Models;

    public interface IRadnikService
    {
        List<Radnik> GetAllRadnici();  

        Radnik GetRadnikById(int id); 

        void CreateRadnik(Radnik radnik); 

        void UpdateRadnik(Radnik radnik);  

        void DeleteRadnik(Radnik radnik);  
    }
}