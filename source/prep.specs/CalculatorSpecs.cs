using Machine.Specifications;
using prep.learning_mspec;

namespace prep.specs
{
  public class CalculatorSpecs
  {
    public class when_adding_two_numbers
    {
      It should_return_the_sum = () =>
        Calculator.add(2, 3).ShouldEqual(5);
    }
  }
}