local SubPanel = {

}
setmetatable(SubPanel, {__index = UIComponent})


function SubPanel:OnCreateComponent( )
	print("SubPanel:OnCreateComponent")
end

function SubPanel:OnInitComponent( ) 
	print("SubPanel:OnInitComponent")
end

function SubPanel:OnReleaseComponent( ) 
	print("SubPanel:OnReleaseComponent")
end

return SubPanel