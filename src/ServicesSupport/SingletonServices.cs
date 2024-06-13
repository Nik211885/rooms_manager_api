using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;
using System.Runtime.CompilerServices;

namespace src.ServicesSharedSupport
{
    public class SingletonServices
    {
        private static IEnumerable<ServiceSupport>? _servicesSupport;    
        private SingletonServices() { }
        /// <summary>
        ///     This function create one instance admin support services 
        /// </summary>
        /// <param name="dbContext">Pass section working database</param>
        /// <returns>Get all services admin still support</returns>
        /// 
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEnumerable<ServiceSupport>? GetIntentServicesProvide(RoomsManagerDbConText dbContext)
        {
            if(_servicesSupport == null)
            {
                _servicesSupport = dbContext.ServicesSupport.Where(x=>!x.Deleted).ToList();
            }
            return _servicesSupport;
        }

    }
}
