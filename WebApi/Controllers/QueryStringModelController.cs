using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    /// <summary>
    /// <author>114233762@qq.com</author>
    /// </summary>
    public class QueryStringModelController : ApiController
    {
        #region SimpleObject
        public class SimpleModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool Is80s { get; set; }
        }

        [HttpGet]
        [Route("api/QueryStringModel/SimpleObject")]
        public string SimpleObject([FromUri] SimpleModel model)
        {
            return $"get:{Newtonsoft.Json.JsonConvert.SerializeObject(model)}";
        }
        #endregion

        #region ArrayObject

        [HttpGet]
        [Route("api/QueryStringModel/ArrayObject")]
        public string ArrayObject([FromUri] IList<string> model)
        {
            return $"get:{Newtonsoft.Json.JsonConvert.SerializeObject(model)}";
        }
        #endregion

        #region ArrayInObject
        public class ArrayInObjectModel
        {
            public IList<ArrayInObjectModelItem> Languages { get; set; }
        }

        public class ArrayInObjectModelItem
        {
            public string Name { get; set; }
        }


        [HttpGet]
        [Route("api/QueryStringModel/ArrayInObject")]
        public string ArrayInObject([FromUri] ArrayInObjectModel model)
        {
            return $"get:{Newtonsoft.Json.JsonConvert.SerializeObject(model)}";
        }
        #endregion

        #region ArrayInObject2
        public class ArrayInObjectModel2
        {
            public IList<string> A { get; set; }
        }

        [HttpGet]
        [Route("api/QueryStringModel/ArrayInObject2")]
        public string ArrayInObject2([FromUri] ArrayInObjectModel2 model)
        {
            return $"get:{Newtonsoft.Json.JsonConvert.SerializeObject(model)}";
        }
        #endregion

        #region Tree
        public class TreeModel
        {
            public string Name { get; set; }
            public IList<TreeModel> Children { get; set; }

            public int Level { get; set; }
        }

        [HttpGet]
        [Route("api/QueryStringModel/TreeObject")]
        public string TreeObject([FromUri] TreeModel model)
        {
            return $"get:{Newtonsoft.Json.JsonConvert.SerializeObject(model)}";
        }
        #endregion

        #region BinaryTree
        public class BinaryTreeModel
        {
            public string Value { get; set; }
            public BinaryTreeModel Left { get; set; }
            public BinaryTreeModel Right { get; set; }
        }

        [HttpGet]
        [Route("api/QueryStringModel/BinaryTreeObject")]
        public string BinaryTreeObject([FromUri] BinaryTreeModel model)
        {
            return $"get:{Newtonsoft.Json.JsonConvert.SerializeObject(model)}";
        }
        #endregion

        #region ObjectInArray
        public class ObjectInArrayModel
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        [HttpGet]
        [Route("api/QueryStringModel/objectInArray")]
        public string ObjectInArray([FromUri] IList<ObjectInArrayModel> model)
        {
            return $"get:{Newtonsoft.Json.JsonConvert.SerializeObject(model)}";
        }
        #endregion

        #region DictionaryObject
        [HttpGet]
        [Route("api/QueryStringModel/DictionaryObject")]
        public string DictionaryObject([FromUri] Dictionary<string,string> model)
        {
            return $"get:{Newtonsoft.Json.JsonConvert.SerializeObject(model)}";
        }
        #endregion
    }
}
