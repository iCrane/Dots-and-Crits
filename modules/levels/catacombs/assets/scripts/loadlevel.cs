function catacombs::loadlevel(%this)//change catacombs to your module name
{
cancelallschedules();
DotsandCritsscene.clear();

if ($view==0)
{
%this.loadedscene=TamlRead("./../../scenes/topdown.scene.taml");
}
else
{
%this.loadedscene=TamlRead("./../../scenes/sideview.scene.taml");
}

if (!isObject(%this.loadedscene))
{
echo("couldn't read taml");
}

%this.loadedscene.setName("");
setCustomScene(%this.loadedscene);

if ($view==0)
{
DotsandCritsscene.setGravity(0,0);
}
else
{
$levelgravity=-20;//can set to a custom number
DotsandCritsscene.setGravity(0,$levelgravity);
}

if (isObject(gui_catacombsscore))
{
gui_catacombsscore.delete();
}
DotsandCrits.add(TamlRead("./../gui/score.gui.taml"));
Canvas.pushDialog(gui_catacombsscore);

//init npc's
for (%x=0;%x<DotsandCritsscene.getCount();%x++)
{
%obj=DotsandCritsscene.getObject(%x);
if (%obj.SceneGroup==25)//npc
{
%obj.initialize();
}
}

}
