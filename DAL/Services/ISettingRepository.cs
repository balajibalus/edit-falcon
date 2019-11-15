using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
namespace DAL.Services
{
    public interface ISettingRepository
    {
        List<Colors> GetColors();
        Colors GetColor(int id);
        string AddColor(Colors colors);
        string EditColor(Colors colors);
        void Deletes(Colors colors);
       

        List<Country> Countries();
        Country GetCountry(int id);
        string AddCountry(Country country);
        void EditCountry(Country country);
        void DeleteCountry(Country country);

        List<Disease> GetDiseases();
        Disease GetDisease(int id);
        string AddDisease(Disease disease);
        void EditDisease(Disease disease);
        void DeleteDisease(Disease disease);

        List<ScientificName> GetNames();
        ScientificName GetScientific(int id);
        string AddName(ScientificName scientific);
        void EditName(ScientificName scientific);
        void DeleteScientificName(ScientificName scientific);

        List<Seasons> GetSeasons();
        Seasons GetSeason(int id);
        string AddSeasons(Seasons seasons);
        void EditSeason(Seasons seasons);
        void DeleteSeason(Seasons seasons);
        void Default(Seasons seasons);


        List<Species> GetSpecies();
        Species GetSpecie(int id);
        string AddSpecies(Species species);
        void EditSpecie(Species species);
        void DeleteSpecies(Species species);

        List<Status> GetStatuses();
        Status GetStatus(int id);
        string AddStatus(Status status);
        void EditStatus(Status status);
        void DeleteStatus(Status status);

        List<Gender> Gender();

    }
}
