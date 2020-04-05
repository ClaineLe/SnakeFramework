local CSButton = CS.UnityEngine.UI.Button
UIUtil = {
	gameObject = nil,
	rectTransform = nil,

	listeners = nil,
}

function UIUtil:SetupUtil(rectTransform)
	self.rectTransform = rectTransform
	self.gameObject = rectTransform.gameObject
	self.listeners = {}
end

function UIUtil:RemoveListeners( )
	for i,v in ipairs(self.listeners) do
		v.key.onClick:RemoveListener(v.value)
	end
	self.listeners = {}
end

function UIUtil:get_transform( path )
	return self.rectTransform:Find(path)
end

function UIUtil:add_button( path, func)
	local node = self:get_transform(path)
	if node then 
		local btn = node:GetComponent(typeof(CSButton))
		if btn then 
			local handler = handler(func, self)
			table.insert(self.listeners, {key = btn, value = handler})
			btn.onClick:AddListener(handler)
		end
	end
end

function UIUtil:get_subscreen( path )
	local node = self:get_transform(path)
	if node then
		local componentName = path_get_filename_without_extension(path) 
		local fullpath = string.format(PathConst.UI_COMPONENT_PATH, componentName)
		local component = require(fullpath)
		component:CreateComponent(node)
		return component
	end
end
