using Bussines.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrate
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                new InvalidOperationException("Renk ismi 2 karkterden büyük olmalı");
            }
            else
            {
                _colorDal.Add(color);
            }

        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c=>c.Id == id);
        }

        public void Update(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                new InvalidOperationException("Renk ismi 2 karkterden büyük olmalı");
            }
            else
            {
                _colorDal.Update(color);
            }
        }
    }
}
