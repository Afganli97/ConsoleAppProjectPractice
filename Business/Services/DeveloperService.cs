using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class DeveloperService : IDeveloper
    {
        public DeveloperRepository developerRepository { get; set; }
        public static int Count { get; set; }
        public DeveloperService()
        {
            developerRepository = new DeveloperRepository();
        }

        public Developer Create(Developer developer)
        {
            try
            {
                developer.Id = ++Count;
                developer.project.NumberOfDevelopers = Count;
                developerRepository.Create(developer);
                return developer;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Developer Delete(int id)
        {
            try
            {
                Developer existDeveloper = developerRepository.Get(d=>d.Id == id);
                existDeveloper.project.NumberOfDevelopers--;
                existDeveloper.project.developers.Remove(existDeveloper);
                developerRepository.Delete(existDeveloper);
                return existDeveloper;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Developer Get(int id)
        {
           return developerRepository.Get(d => d.Id == id);
        }

        public Developer Get(string name)
        {
            return developerRepository.Get(d => d.Name.ToLower() == name.ToLower());
        }

        public List<Developer> GetAll()
        {
            return developerRepository.GetAll();
        }

        public Developer Update(int id, Developer developer)
        {
            try
            {
                Developer existDeveloper = developerRepository.Get(d => d.Id == id);
                if (existDeveloper != null)
                {
                    existDeveloper.Name = developer.Name;
                    return existDeveloper;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
