using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataLibrary
{   [KnownType(typeof(ExtendedProduct))] // if we disable this , the extended class won't be able to get serialized with base class reference into serializer. 
    [DataContract(Name="FashionProduct", Namespace="http://learningWCF.com")]
    public class Product
    {
        [DataMember(Name="FashionProductName" ,Order=1)]
        public String Name;
        [DataMember(Name = "FashionProductType", Order =2)]
        public String Type;
        [DataMember(Name="FupdateTime",Order=3)]
        public DateTime UpdateTime;
        [DataMember(Name="Remarks",Order=4)]
        public String Comments;
        /*Filed below marks the field as required where as emitdefault value will ensure that if field value isn't provided, the field doesn't get 
         serialized. If that's the case, while deserializing the same file, we will get an exception as the filed is required.*/
        [DataMember(IsRequired=true,EmitDefaultValue=true, Name="RequiredField",Order=5)]
        public String ProductId;
    }


    /*
     * Main reason for the extended class is show following:
     * it derives from the base class product. during the serialization, we only provided base class as a type to serialize
     * and yet still, we passed the Extended product into the serializer. this has two implications.
     * a) it will fail if the base class isn't told about the class which is serializing itself.(Use knowntype at the base class).
     * b) after adding a knowntype to the base class we can easily serialize the class, 
     * even if the reference to the base class was used for the serialization.
     */
    [DataContract]
    public class ExtendedProduct : Product
    {
        [DataMember] public String Designer;
    }
  
}
