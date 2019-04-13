﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CodeBattle.Models;
using CodeBattle.Services;
using Microsoft.AspNetCore.Mvc;
using Json;
using Microsoft.AspNetCore.Http;

namespace CodeBattle.Controllers
{
    [Route("api-v1/[controller]")]
    public class MapController : Controller
    {
        private readonly MapService _MapService;

        public MapController(MapService mapService)
        {
            _MapService = mapService;
            
        }
        // TODO словарь некорректно(None) преобразуется в BsonElement когда отсылается в коллекцию


        [HttpPost]
<<<<<<< HEAD
        public ActionResult<Map> Post(Map books)
        {
            /* var map_create =_MapService.Create(map);
             if(map_create == null)
             {
                 return NoContent();
             }
             else
             {
                 return map;
             }*/
            return Json(books);
=======
        public ActionResult Post(Map map)
        {
            /*var map_create =_MapService.Create(map);
            if(map_create == null)
            {
                return NoContent();
            }
            else
            {
                return map;
            }*/
       
            return Json(map);
>>>>>>> 5a10879df096154dbe648989da24bf1e065c9de4
        }

        [HttpGet("{index:max(50)}")]
        public ActionResult<Map> Get(int index)
        {
            var map_get = _MapService.Get(index);
            if (map_get == null || index == 0)
            {
                return NoContent();
            }
            else
            {
                return map_get;
            }
        }
    }
}
