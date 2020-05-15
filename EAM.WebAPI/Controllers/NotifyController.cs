using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAM.Common.Entities;
using EAM.Application;
using EAM.Application.Services;
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
        private readonly IBService<NotifyService> _service;

        public NotifyController(ILogger<NotifyController> logger, IBService<NotifyService> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("fulllist")]
        public List<NotificationList> FullList(int del)
        {
            try
            {
                var userid = Convert.ToInt32(this.User.Identity.Name);
                return _service.Provider.GetAdminList(del == 1);
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
                var userid = Convert.ToInt32(this.User.Identity.Name);
                return _service.Provider.UserNotificationList(userid);
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
                var userid = Convert.ToInt32(this.User.Identity.Name);
                return _service.Provider.ActionTaken(nid, userid);
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
                return _service.Provider.AssignToUsers(sentObj);
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
                var userid = Convert.ToInt32(this.User.Identity.Name);

                var id = _service.Provider.CreateNotification(notification, userid);
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
                var userid = Convert.ToInt32(this.User.Identity.Name);

                return _service.Provider.GetOne(nid, userid);
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
                var userid = Convert.ToInt32(this.User.Identity.Name);

                return _service.Provider.DeleteOne(idObj.id, userid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DeleteOne");
                throw new Exception("Unable to fetch");
            }
        }
    }
}