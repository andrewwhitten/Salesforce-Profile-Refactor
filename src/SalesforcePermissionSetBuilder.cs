using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.Linq;

namespace SalesforceProfileRefactor
{
    public class SalesforcePermissionSetBuilder
    {
        /// <summary>
        /// Convert a Profile into a valid Permission Set
        /// </summary>
        /// <param name="subsetProfileFileName"></param>
        /// <param name="subsetProfile"></param>
        /// <returns></returns>
        /// <remarks>The Salesforce PermissionSet schema is different to the Profile schema, and therefore we need to change the name and remove unsupported elements.</remarks>
        public static bool GeneratePermissionSet(string subsetProfileFileName, Profile subsetProfile)
        {
            bool success = false;

            using (var ms = new MemoryStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(ms))
                {
                    XmlSerializer serializerOutputSubset = new XmlSerializer(typeof(Profile));
                    serializerOutputSubset.Serialize(streamWriter, subsetProfile);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);

                    // Load the Profile XML document in memory into an XDocument for manipulation
                    XDocument doc = XDocument.Load(ms);
                    XNamespace xNs = "http://soap.sforce.com/2006/04/metadata";

                    // Remane from 'Profile' to PermissionSet. Keep correct namespace.
                    XElement profileElement = doc.Descendants(@"{http://soap.sforce.com/2006/04/metadata}Profile").First();
                    profileElement.RemoveAttributes(); // Previous steps added unrequired attributues.
                    profileElement.Name = xNs + "PermissionSet";

                    XElement license = new XElement(xNs + "license", "Salesforce");
                    profileElement.AddFirst(license);

                    XElement label = new XElement(xNs + "label", "Common Permission Set");
                    profileElement.AddFirst(label);

                    XElement hasActivationRequired = new XElement(xNs + "hasActivationRequired", "false");
                    profileElement.AddFirst(hasActivationRequired);

                    XElement descriptionElement = new XElement(xNs + "description", "Common Permission Set");
                    profileElement.AddFirst(descriptionElement);

                    // The 'custom' element is not supported by the Permission Set schema
                    doc.Root.Descendants(@"{http://soap.sforce.com/2006/04/metadata}custom").Remove();

                    // Save the Permission Set
                    doc.Save(subsetProfileFileName);

                    success = true;
                }
            }

            return success;
        }
    }
}
