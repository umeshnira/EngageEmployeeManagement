using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAM.Common.Entities;
using EAM.Data;
using EAM.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EAM.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly ILogger<NotifyController> _logger;
        private readonly IRepository<NotifyRepository> _repository;

        public NotifyController(ILogger<NotifyController> logger, IRepository<NotifyRepository> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("fulllist")]
        public List<NotificationList> FullList(int del)
        {
            try
            {
                var principal = this.User;
                var userid = Convert.ToInt32(principal.Claims.Where(x => x.Type == "userid").First().Value);
                return _repository.Provider.GetAdminList(del == 1);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Users' List");
                throw new Exception("Unable to fetch");
            }
        }

        [HttpGet]
        [Route("userslist")]
        public List<Notification> UsersList()
        {
            try
            {
                var principal = this.User;
                var userid = Convert.ToInt32(principal.Claims.Where(x => x.Type == "userid").First().Value);
                return _repository.Provider.UserNotificationList(userid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Users' List");
                throw new Exception("Unable to fetch");
            }
        }
        [HttpGet]
        [Route("actiontaken")]
        public bool ActionTaken(long nid)
        {
            try
            {
                var principal = this.User;
                var userid = Convert.ToInt32(principal.Claims.Where(x => x.Type == "userid").First().Value);
                return _repository.Provider.ActionTaken(nid, userid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Action Taken");
                throw new Exception("Unable to fetch");
            }
        }
        [HttpPost]
        [Route("assigntouser")]
        public bool AssignToUser(NotificationSent sentObj)
        {
            try
            {
                return _repository.Provider.AssignToUsers(sentObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AssignToUser");
                throw new Exception("Unable to fetch");
            }
        }

        [HttpPost]
        [Route("addone")]
        public SuccessObj<long> AddOne(Notification notification)
        {
            try
            {
                var principal = this.User;
                var userid = Convert.ToInt32(principal.Claims.Where(x => x.Type == "userid").First().Value);

                var id = _repository.Provider.CreateNotification(notification, userid);
                return new SuccessObj<long>() { result = id, success = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "AddOne");
                throw new Exception("Unable to fetch");
            }
        }

        [HttpGet]
        [Route("getone")]
        public Notification GetOne(long nid)
        {
            try
            {
                var principal = this.User;
                var userid = Convert.ToInt32(principal.Claims.Where(x => x.Type == "userid").First().Value);

                return _repository.Provider.GetOne(nid, userid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetOne");
                throw new Exception("Unable to fetch");
            }
        }


        [HttpPost]
        [Route("deleteone")]
        public bool DeleteOne(PostObj<long> idObj)
        {
            try
            {
                var principal = this.User;
                var userid = Convert.ToInt32(principal.Claims.Where(x => x.Type == "userid").First().Value);

                return _repository.Provider.DeleteOne(idObj.id, userid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteOne");
                throw new Exception("Unable to fetch");
            }
        }
    }
}