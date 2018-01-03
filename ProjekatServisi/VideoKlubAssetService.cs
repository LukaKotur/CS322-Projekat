using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjekatData;
using ProjekatData.Models;

namespace ProjekatServisi
{
    public class VideoKlubAssetService : IVideoKlubAsset
    {
        #region Fields / Constructor

        private DataContext _context;

        public VideoKlubAssetService(DataContext context)
        {
            _context = context;
        }

        #endregion

        #region Getters

        public IEnumerable<VideoKlubAsset> GetAll()
        {
            return _context.VideoKlubAsset
                .Include(h => h.Status)
                .Include(i => i.Lokacija);
        }

        public VideoKlubAsset GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.Id == id);
        }


        public string GetGlavniGlumci(int id)
        {
            if (_context.Film.Any(film => film.Id == id))
            {
                return _context.Film.FirstOrDefault(film => film.Id == id).GlavniGlumci;
            }
            else
            {
                return "";
            }
        }

        public string GetNaziv(int id)
        {
            return _context.VideoKlubAsset.FirstOrDefault(asset => asset.Id == id).Naziv;
        }

        public string GetProducent(int id)
        {
            if (_context.Film.Any(film => film.Id == id))
            {
                return _context.Film.FirstOrDefault(film => film.Id == id).Producent;
            }
            else
            {
                return "";
            }
        }

        public VideoKlubOgranak GetCurrentOgranak(int id)
        {
            return GetById(id).Lokacija;
        }

        #endregion

        #region Add

        public void Add(VideoKlubAsset novi)
        {
            _context.Add(novi);
            _context.SaveChanges();
        }

        #endregion
    }
}