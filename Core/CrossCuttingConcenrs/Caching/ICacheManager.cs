using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcenrs.Caching
{
    public interface ICacheManager
    {
        //Cacheden bir data getirmek için herhangibir veri olabileceği için Generic yapıyoruz
        T Get<T>(string key);
        //Generic olanın alternatifi ama tür dönüşümlerini yapmak gerekiyor
        object Get(string key);
        // Cahche veri eklemek için
        void Add(string key, object value, int duration);
        //Cahce de var mı?
        bool IsAdd(string key);
        // Cache den silmek için
        void Remove(string key);
        //verdiğimiz pattern e göre silmek için Örn: isiminde Get, Category olanlar gibi.
        void RemoveByPattern(string pattern);
    }
}
