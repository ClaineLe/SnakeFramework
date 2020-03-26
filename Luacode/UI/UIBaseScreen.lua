local CSButton = CS.UnityEngine.UI.Button
UIBaseScreen = {
	__path = nil,

	mGameObject = nil,
	mTransform = nil,
	mRectTransform = nil,

	mListeners = nil,
}

setmetatable(UIBaseScreen, {__index = ILuaScreenInterface})


function UIBaseScreen:LoadSuccess( screenRoot, luaPath )
	self.mGameObject = screenRoot
	self.mTransform = screenRoot.transform
	self.mListeners = {}

	self.__path = luaPath
	self:OnLoadSuccess()
end
function UIBaseScreen:Release( )
	self:OnRelease()
	self:RemoveListeners()
end

function UIBaseScreen:OnLoadSuccess( )
	-- body
end
function UIBaseScreen:OnRelease( )
	-- body
end

function UIBaseScreen:get_transform( path )
	return self.mTransform:Find(path)
end

function UIBaseScreen:add_button( path, handle)
	local node = self:get_transform(path)
	if node then 
		local btn = node:GetComponent(typeof(CSButton))
		if btn then 
			local handler = handler(handle, self)
			table.insert(self.mListeners, {key = btn, value = handler})
			btn.onClick:AddListener(handler)
		end
	end
end

function UIBaseScreen:get_subscreen( path, subScreenName)
	local node = self:get_transform(path)
	if node then
		local subScreenName = path_get_filename_without_extension(path) 
		local fullpath = string.format("UI.SubScreen.%s", subScreenName)
		local subScreen = require(fullpath)
		subScreen:LoadSuccess(node, fullpath)
	end
end

function UIBaseScreen:RemoveListeners( )
	for i,v in ipairs(self.mListeners) do
		v.key.onClick:RemoveListener(v.value)
	end
	self.mListeners = {}
end