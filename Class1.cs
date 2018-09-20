using System;
using System.Management.Automation;

namespace update_host
{
  public class Person {
   public string FirstName { get; set; }
   public string LastName { get; set; }

   public Person(string first, string last) {
     this.FirstName = first;
     this.LastName = last;
   }
  }

  [CmdletAttribute(VerbsCommon.New, "Person")]
  public class NewPersonCmdlet : Cmdlet {
    protected override void ProcessRecord() {
      WriteObject(new Person("Trevor", "Sullivan"));
    }
  }
}
