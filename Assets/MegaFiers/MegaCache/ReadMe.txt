Please see the MegaCacheDocs.pdf included in the system for full explantion of all params and how to use the system along with example videos. The docs can also be found online at our website at www.megafiers.com

Introduction
MegaCache is an editor extension of for the Unity game engine, it allows you to import cached animated mesh geometry regardless of the topology, vertex count, material use etc of each mesh in the cached sequence as well as importing Particle systems exported from 3d packages. The system can accept a sequence of OBJ files where each file can have a number of objects all with different materials, MegaCache will import the sequence of files merging multiple objects and material sub meshes into a single mesh object for you, you can then play back the imported sequence either by asking the system to directly change the mesh using its stored list of generated meshes, or the sequence can be read from a generated cache file, or finally be read from a memory based image file. Play back of the animation is blazingly fast no matter which option you choose with the system making use of multiple threads where possible to further increase performance. You can also tell MegaCache to optimize the data that is imported reducing the memory use to under a 1/3rd of storing raw mesh data.

MegaCache is perfect for exporting complex animated meshes that are not possible to recreate using skin and bones, such as fluid simulations, fracturing objects, cloth simulations or anything where the vertex count, face count, materials etc change during the course of the animation. It is also perfect for playing back complex animations made using modifiers or deformers in 3d packages, all the animation can be baked down to a sequence of frames using standard OBJ sequence exporters which are available for all the 3d packages.

Included in the system are components to allow the import of a sequence of OBJ files and play those back as well as an OBJ reference component where multiple objects can playback a sequence from an already loaded source so dozens of objects can all be sharing the same data but playing back at different speeds or positions. Also included are components to playback imported particle simulations either on the Unity Shuriken particle system or the Legacy system.

Particle Simulations
As well as importing sequences of Mesh geometry MegaCache can also import and playback particle systems such as Particle Flow simulations from 3ds max. Again the system will optimize the memory use for imported simulation and gives you complete control over the playback of the particles, selecting emit rate, scales, speeds etc and works alongside the existing Unity Shuriken and Legacy particle systems allowing you to add even more detail to the finished particle animation.

Particle Exporters
At release we have available an exporter for 3ds max to exporter Particle Flow simulations, we also have a beta Maya exporter for Maya particle system exporting, please note the Maya plugin is still a work in progress. If you require the exporters please get in touch with the invoice number for your purchase and we will send the exporter of to you.

MegaCache Object
The OBJ Cache system in MegaFiers is a basic version of the system found in the full MegaCache Asset. It allows you to import any number of OBJ files as a sequence and then play those back in Unity. Each OBJ file in the sequence can have any number of vertices (up to the limit of Unity of 65535) and the counts can change between files as well as the face count, texture coordinates etc. If the OBJ files have materials then those will be imported as well and the system will combine all the mesh and material data into a single object.

You can then select to use the mesh data as it was imported but that can take a lot of memory depending on how many files were imported, or you can save the data to an optimized Cache file which massively reduces the memory as the system will compress the data for you. If you use a a cache file as the source the system will stream each frame as it is needed so the memory use comes down to a single frames worth of memory instead of all the data. Or you can choose to make a memory based image of the data for even faster streaming of the data, this option also supports the option for using another thread to pre fetch the next frame of data for you.

How to use
Using the system is very simple, go to the GameObject/Create Other/MegaCache menu and select the OBJ Cache option, this will create a new game object in the scene for you with the required components attached. Next you need to set the frame range for OBJ files that you wish to import, so say for example you exported a sequence of 100 frames from your 3d package called Object_0001.obj to Obj_0100.obj then you would set the 'First' value to 0 and the 'Last' to 100. You have the option to only load every nth frame if you wish to reduce memory use, if you want every frame from the sequence then set skip to 1, otherwise set how many frames you want to skip.

Next you need to set the Format slider so that the system knows how long the sequence number is in the file name, so for our example the Format would be 4 as the numbers are 4 digits long. Next click the Load Frames button, and then select any frame from the sequence you wish to import and click Open. The system will now show a progress bar as it imports the data. When the data has finished importing you should see the first frame of your sequence in your scene.

It may be the object is too big or small, each 3d package uses different scales for its scenes but you can compensate for that by changing the Import Scale value much as you would importing any object into Unity. Another thing to note is different 3d packages use different coordinate systems, if you find your object is flipped on the X axis then check the Adjust Coords option and reimport the frames.

One other thing to note is most OBJ exporters will use world coordinates for the vertex values, so it is good practice to centre your object at 0,0,0 in the 3d package before you export the sequence so that the pivot will be in the right place.

MegaCache Obj Ref
The OJB Ref system allows you to make use of the object cache data that is already being used by a Cache object in the scene, this allows to to have multiple copies of the animated mesh all with different playback options and current frames but without any of the extra memory overhead of storing the cache data for each image, this helps make the Cache system much more useable in your game projects as you could have say one building collapsing or levelling up animation but use it dozens of times in your scene with no extra memory use.

How to use
Using this system is very easy, just got to the GameObject/Create Other/MegaCache menu and select OBJ Ref, this will create a new gameobject in the scene with all the components required attached, you just then need to click the source value in the inspector and select the MegaCache Object in the scene that has the cache data you wish to use, once selected you will see the mesh in the scene, you can then use the frame slider or animation controls to play back that sequence independently of the original MegaCache object.

MegaCache Particle
The MegaCache Particle system allows you export particle systems from 3d packages and import them into Unity, you can control the scale, speed and emit rate of the system as it plays back either system wide or per particle. The system works alongside the Shuriken values so you can make use of the features in that to further enhance the imported simulation. The imported data is optimized and compressed to make playback of the simulation very fast, and you can also select a source object to be able to share the cached data so keeping memory use as low as possible. There is also a version of this system for the Legacy particle system in Unity.

How to Use
To use the particle system you would first have created your simulation in 3ds max or Maya (support for other systems coming soon) and exported it to a cache file using one of our exporters. Next in Unity goto the GameObject/Create Other/MegaCache menu and select the Particle Pro option, this will create a new game object in the scene with the component attached, or you can add the component directly to any object or to an object with a Shuriken Particle system on it.

If you have not attached the component to a particle system then select the one using the Particle System option in the inspector, you should then set the Max Particles value to match that of the particle system you just selected. Depending on the settings you have in the 3d package that created the particle system you may need to set the Import Scale option, if when you import the particle simulation it is too big or small then adjust the Import Scale value and reimport the file. Click the Import Particle Cache button and select the cache file generated by the exporter, the system will then load all the data. You can change the Import settings if you know you dont need parts of the saved data, so if you just need the positions then uncheck the other options, this will keep the memory use as low as possible.

You are now ready to have the system play back, when you press play the particles will start to play back the saved simulation, if you turn of the emit option on the Shuriken settings and check the Use Emit Rate then you can control the emission of particles from the this component. You can ask the system to pre warm the simulation, and you can adjust the overall scale and play back speed of the simulation as well as the speed and scale for newly emitted particles.

When you are happy with how the particle system works you can click the Save Particle Cache File to save an optimized version of the simulation data for quicker loading or you can load a pre saved file.

It could be that you want to have more than one copy of the particle simulation in your scene, creating a whole new system and importing the same data would waste a lot of memory, so you can just add the component and then select a MegaCache particle system that already exists in the scene, the component will then use the data on that object as well allowing you to have lots of particle system without the memory overhead.

MegaCache Particle Legacy
The MegaCache Particle system allows you export particle systems from 3d packages and import them into Unity, you can control the scale, speed and emit rate of the system as it plays back either system wide or per particle. The system works alongside the Legacy particle values so you can make use of the features in that to further enhance the imported simulation. The imported data is optimized and compressed to make playback of the simulation very fast, and you can also select a source object to be able to share the cached data so keeping memory use as low as possible. There is also a version of this system for the Shuriken particle system in Unity.

How to Use
To use the particle system you would first have created your simulation in 3ds max or Maya (support for other systems coming soon) and exported it to a cache file using one of our exporters. Next in Unity goto the GameObject/Create Other/MegaCache menu and select the Particle Pro Legacy option, this will create a new game object in the scene with the component attached, or you can add the component directly to any object or to an object with a Shuriken Particle system on it.

If you have not attached the component to a particle system then select the one using the Particle System option in the inspector, you should then set the Max Particles value to match that of the particle system you just selected. Depending on the settings you have in the 3d package that created the particle system you may need to set the Import Scale option, if when you import the particle simulation it is too big or small then adjust the Import Scale value and reimport the file. Click the Import Particle Cache button and select the cache file generated by the exporter, the system will then load all the data. You can change the Import settings if you know you dont need parts of the saved data, so if you just need the positions then uncheck the other options, this will keep the memory use as low as possible.

You are now ready to have the system play back, when you press play the particles will start to play back the saved simulation, if you turn of the emit option on the Shuriken settings and check the Use Emit Rate then you can control the emission of particles from the this component. You can ask the system to pre warm the simulation, and you can adjust the overall scale and play back speed of the simulation as well as the speed and scale for newly emitted particles.

When you are happy with how the particle system works you can click the Save Particle Cache File to save an optimized version of the simulation data for quicker loading or you can load a pre saved file.

It could be that you want to have more than one copy of the particle simulation in your scene, creating a whole new system and importing the same data would waste a lot of memory, so you can just add the component and then select a MegaCache particle system that already exists in the scene, the component will then use the data on that object as well allowing you to have lots of particle system without the memory overhead.

Version History:
v1.09
Added option to particle import to remove particles alive in last frame from import.
Improved particle importer to remove particles that only have one frame of data.
Added a new Particle Playback component for direct particle playback as opposed to the emitter version, means one shot effects like explosions etc can be used as opposed to constant effects like smoke.
Added playback component for legacy particles as well.

v1.08
Removed the unused function LoadTexture which was causing a compile error when building for webplayer.

v1.07
Fully Unity 5 compatible.

v1.06
Smoke in demo scene working correctly.
Added a beta of a new Point Cloud import and playback system.
Works with Unity 5

v1.05
Fixed bug in Particle Inspector
Fixed bug in Legacy Particle Inspector
Added a beta exporter for Blender to export Blender particle systems to MegaCache prt format.

v1.04
Fixed bug with particle importers wanting .txt extension instead of .prt generated by the Max exporter.

v1.03
Demo scene was saved using a file as a data source which would not work without the cache file. Demo scene now uses an 'Image' data source.

v1.02
Added option to update mesh collider for Object Cache.
Added option to update mesh collider for Object Cache Ref.

v1.01
Added a runtime folder option for OBJ Cache files, cache files for standalone builds need to be copied the data folder for the build after the Unity build.

1.00
Initial release.