    class RenderCubemapWizard extends ScriptableWizard {
        var renderFromPosition : Transform;
        var cubemap : Cubemap;
        
        function OnWizardUpdate (){
            helpString = "Select transform to render from and cubemap to render into";
            isValid = (renderFromPosition != null) && (cubemap != null);
        }
        
        function OnWizardCreate (){
            var go = new GameObject("CubemapCamera", Camera);
            go.transform.position = renderFromPosition.position;
            go.transform.rotation = Quaternion.identity;  
            go.camera.RenderToCubemap(cubemap);            
            DestroyImmediate(go);
        }
        
        @MenuItem("GameObject/Render into Cubemap")
        static function RenderCubemap(){
            ScriptableWizard.DisplayWizard.<RenderCubemapWizard>("Render cubemap", "Render!");
        }
    }  