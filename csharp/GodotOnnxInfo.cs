using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using Godot;
using Microsoft.ML.OnnxRuntime;

namespace com.akjava
{
    public partial class GodotOnnxInfo : GodotObject
    {
        
        public GodotOnnxInfo(string modelPath)
        {
            GD.Print(modelPath);
             var session = new InferenceSession(modelPath);
            GD.Print(session.ModelMetadata);
            var meta_data = session.ModelMetadata;
            GD.Print("Description :" + meta_data.Description);
            GD.Print("Domain :" + meta_data.Domain);
            GD.Print("GraphDescription :" + meta_data.GraphDescription);
            GD.Print("GraphName :" + meta_data.GraphName);
            GD.Print("ProducerName :" + meta_data.ProducerName);
            GD.Print("Version :" + meta_data.Version);
            GD.Print("Dict-Count :" + meta_data.CustomMetadataMap.Count);
            foreach (KeyValuePair<string, string> entry in meta_data.CustomMetadataMap)
            {
                //GD.Print(entry);
                GD.Print($"Key: {entry.Key}, Value: {entry.Value}");
            }
            GD.Print("Input-Count :" + session.InputNames.Count);
            foreach (KeyValuePair<string, NodeMetadata> entry in session.InputMetadata)
            {
                //GD.Print(entry);
                GD.Print($"Key: {entry.Key}");
                var node_metadata = entry.Value;
                var value_type = node_metadata.OnnxValueType;

                //string[] value_type_names = Enum.GetNames(typeof(OnnxValueType));

                GD.Print("ValueType:" + value_type.ToString());
                if (value_type == OnnxValueType.ONNX_TYPE_TENSOR)
                {
                    var dimensions = node_metadata.Dimensions;
                    string dimensions_text = string.Join(", ", dimensions);
                    GD.Print($"Dimensions: {dimensions_text}");
                    var element_data_type = node_metadata.ElementDataType;
                    GD.Print($"ElementDataType: {element_data_type.ToString()}");
                    var element_type = node_metadata.ElementType;
                    GD.Print($"ElementType: {element_type.ToString()}");

                    GD.Print($"SymbolicDimensions:{string.Join(", ", node_metadata.SymbolicDimensions)}");


                }

            }


            GD.Print("Output-Count :" + session.OutputNames.Count);
            /*
            foreach (string name in session.OutputNames)
            {
                //var output_meta = session.OutputMetadata(name);
                //GD.Print(entry);
                GD.Print(name);
            }*/
            foreach (KeyValuePair<string, NodeMetadata> entry in session.OutputMetadata)
            {
                //GD.Print(entry);
                GD.Print($"Key: {entry.Key}");
                var node_metadata = entry.Value;
                var value_type = node_metadata.OnnxValueType;

                //string[] value_type_names = Enum.GetNames(typeof(OnnxValueType));

                GD.Print("ValueType:"+value_type.ToString());
                if (value_type == OnnxValueType.ONNX_TYPE_TENSOR)
                {
                    var dimensions = node_metadata.Dimensions;
                    string dimensions_text = string.Join(", ", dimensions);
                    GD.Print($"Dimensions: {dimensions_text}");
                    var element_data_type = node_metadata.ElementDataType;
                    GD.Print($"ElementDataType: {element_data_type.ToString()}");
                    var element_type = node_metadata.ElementType;
                    GD.Print($"ElementType: {element_type.ToString()}");

                    GD.Print($"SymbolicDimensions:{string.Join(", ", node_metadata.SymbolicDimensions)}");


                }

                

            }
            GD.Print($"OverridableInitializerMetadata:{session.OverridableInitializerMetadata.Count}");
            foreach (KeyValuePair<string, NodeMetadata> entry in session.OverridableInitializerMetadata)
            {
                GD.Print($"Key: {entry.Key}");

            }

           
        }

       
    }        

}
