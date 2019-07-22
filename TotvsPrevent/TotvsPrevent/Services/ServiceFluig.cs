using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TotvsPrevent.Services
{
    public class ServiceFluig
    {

        public ServiceFluig()
        {
           
        }
        public async void GetColleagues()
        {
            try
            {
                string username = "Fabrica";
                string password = "totvs";
                int companyId = 1;


                //getColleaguesResponse colleagues = new getColleaguesResponse();

                //ColleagueServiceClient  _clleagueService = new ColleagueServiceClient();


                //colleagues = await _clleagueService.getColleaguesAsync(username, password, companyId);

                //return colleagues.result;
            }
            catch (System.Exception e)
            {
                throw;
            }
           
        }
    }
}
