using ServiceListNumber.Middware;
using Xunit;

namespace BasicAuthTest
{
    public class BasicValidatorShould
    {
        [Fact]
        public void ValidateUserPass()
        {
            //arange definir variables a la hora de probar
            var userpassValidator=new SecurityMiddleware((innerHttpContext)=>{

            });

            //act
            //assert
        }
    }
}
