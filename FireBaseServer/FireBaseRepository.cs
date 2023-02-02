using FireSharp;
using FireSharp.Config;
using System.Net;

namespace FireBaseServer
{
    public class FireBaseRepository
    {
        private FirebaseClient _clientFireBase;

        public FireBaseRepository()
        {
            FirebaseConfig config = new()
            {
                AuthSecret = "jznHLsB71e7UUwqe1XAqxy08jFFgSlbwLGI9n6F8",
                BasePath = "https://databasetest-fe4cc-default-rtdb.firebaseio.com"
            };

            _clientFireBase = new(config);
        }

        public string FireBaseService(int id)
        {
            SetData("cargatransporte/logistica/cargatransporteid", id.ToString());
            return GetData("cargatransporte/logistica/cargatransporteid");
        }

        private void SetData(string path, string data)
        {
            try
            {
                var statusCode = _clientFireBase.SetAsync(path, data).Result.StatusCode;

                if (statusCode != HttpStatusCode.OK)
                    throw new ArgumentException($"Não foi possível realizar a inserção de dado, statuscode: {statusCode}");
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
        }

        private string GetData(string path)
        {
            try
            {
                var response = _clientFireBase.Get(path);

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new ArgumentException($"Não foi possivel realizar a leitura dos dados, statuscode: {response.StatusCode}");

                return response.Body.ToString();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
