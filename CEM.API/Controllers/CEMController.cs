using CEM.Model.Model;
using CEM.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;

namespace CEM.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("ReactPolicy")]
    public class CEMController : Controller
    {
        private readonly ICEMService _cemService;
        private readonly IConfiguration _configuration;
        public CEMController(ICEMService cemService, IConfiguration configuration)
        {
            _cemService = cemService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var responseWrapper = new ResponseWrapper();

            var results = await _cemService.RegisterUserAsync(user);
            if (results == null)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Unable to registered user",
                    Success = false
                };

                return Ok(responseWrapper);
            }
            responseWrapper = new ResponseWrapper
            {
                Message = "Successfully registered",
                Results = results,
                Success = true
            };

            return Ok(responseWrapper);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var responseWrapper = new ResponseWrapper();

            var results = await _cemService.LoginAsync(user.Email, user.Password);
            if (results.Id == 0)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Wrong username or password",
                    Success = false
                };

                return Ok(responseWrapper);
            }
            responseWrapper = new ResponseWrapper
            {
                Message = "Successfully login",
                Results = results,
                Success = true
            };

            return Ok(responseWrapper);
        }

        [HttpPost]
        public async Task<IActionResult> AddComplain([FromBody] Complain complain)
        {
            var responseWrapper = new ResponseWrapper();

            var results = await _cemService.AddComplainAsync(complain);
            if (results == null)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Unable to send your request",
                    Success = false
                };

                return Ok(responseWrapper);
            }
            responseWrapper = new ResponseWrapper
            {
                Message = "Your request has been sent successfully",
                Results = results,
                Success = true
            };

            return Ok(responseWrapper);
        }

        [HttpPost]
        public IEnumerable<Complain> ComplainListByUserId([FromBody] Complain complain)
        {
            var results = _cemService.GetComplainsByUserId(complain.UserId);

            return results;
        }

        [HttpPost]
        public IEnumerable<User_Complain> UserComplainResponseListByUserId([FromBody] User_Complain complain)
        {
            var results = _cemService.GetComplainResponse(complain.ComplainId);

            return results;
        }

        [HttpPost]
        public string UpdateCustomerSatisfaction([FromBody] Complain complain)
        {
            return _cemService.ChangeSatisfaction(complain.Id);
        }


        [HttpPost]
        public string UpdateClosedLog([FromBody] Complain complain)
        {
            return _cemService.ChangeClosedLog(complain.Id);
        }

        [HttpPost]
        public async Task<IActionResult> AddRespond([FromBody] User_Complain user_respond)
        {
            var responseWrapper = new ResponseWrapper();

            var results = await _cemService.AddUserRespond(user_respond);
            if (results.Id == 0)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Unable to send the response",
                    Success = false
                };

                return Ok(responseWrapper);
            }
            responseWrapper = new ResponseWrapper
            {
                Message = "The response has been sent successfully",
                Results = results,
                Success = true
            };

            return Ok(responseWrapper);
        }

        [HttpGet]
        public List<UserComplainDetails> GetAllComplainList()
        {
            var results = _cemService.GetAllAllUsersDetailsAsync().ToList();

            return results;
        }

        [HttpGet("{email}")]
        public Boolean CheckExistingEmail(string email)
        {
            return _cemService.CheckExistingEmail(email);
        }

        [HttpPost]
        public Boolean ChangePassword([FromBody] User user)
        {
            return _cemService.ForgotPassword(user);
        }

        [HttpGet]
        public List<UsersForum> GetAllForumList()
        {
            var results = _cemService.GetAllAllUsersForumAsync().ToList();

            return results;
        }

        [HttpGet]
        public string GetAnalytics()
        {

            ResponseWrapper responseWrapper = new ResponseWrapper();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CEMDb").ToString());
            string sql = "select count(Subject) as SubjectCode, Subject from Complains group by Subject";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Analytics> analyticsList = new List<Analytics>();
            Object Analytics = new object();
            
            if(dt.Rows.Count > 0)
            {
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    Analytics analytics = new Analytics();
                    analytics.ResultCount = Convert.ToInt32(dt.Rows[i]["SubjectCode"]);
                    analytics.NameType = Convert.ToString(dt.Rows[i]["Subject"]);
                    analyticsList.Add(analytics);
                }
            }
            if(analyticsList.Count > 0)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Results List",
                    Success = true,
                    Results = analyticsList
                };

            }
            else
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Unable to find results",
                    Success = false
                };

            }
            return JsonConvert.SerializeObject(responseWrapper);
        }

      

        [HttpGet("{year}")]
        public string GetAnalyticsByYear(int year)
        {

            ResponseWrapper responseWrapper = new ResponseWrapper();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CEMDb").ToString());
            string sql = "select count(Subject) as SubjectCode, Subject from Complains WHERE YEAR(date) = "+ year + " group by Subject";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Analytics> analyticsList = new List<Analytics>();
            Object Analytics = new object();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Analytics analytics = new Analytics();
                    analytics.ResultCount = Convert.ToInt32(dt.Rows[i]["SubjectCode"]);
                    analytics.NameType = Convert.ToString(dt.Rows[i]["Subject"]);
                    analyticsList.Add(analytics);
                }
            }
            if (analyticsList.Count > 0)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Results List",
                    Success = true,
                    Results = analyticsList
                };

            }
            else
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Unable to find results",
                    Success = false,

                };

            }
            return JsonConvert.SerializeObject(responseWrapper);
        }

        [HttpGet]
        public string GetAnalyticsInYears()
        {

            ResponseWrapper responseWrapper = new ResponseWrapper();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("CEMDb").ToString());
            string sql = "select Count(Subject) as subjectCount,year(date) as year from Complains group by year(date)";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Analytics> analyticsList = new List<Analytics>();
            Object Analytics = new object();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Analytics analytics = new Analytics();
                    analytics.ResultCount = Convert.ToInt32(dt.Rows[i]["subjectCount"]);
                    analytics.NameType = Convert.ToString(dt.Rows[i]["year"]);
                    analyticsList.Add(analytics);
                }
            }
            if (analyticsList.Count > 0)
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Results List",
                    Success = true,
                    Results = analyticsList
                };

            }
            else
            {
                responseWrapper = new ResponseWrapper
                {
                    Message = "Unable to find results",
                    Success = false
                };

            }
            return JsonConvert.SerializeObject(responseWrapper);
        }

    }

}


