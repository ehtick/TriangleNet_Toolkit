/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2022, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using BH.oM.Geometry;
using BH.oM.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BH.Engine.Geometry;
using BH.oM.Base;
using System.ComponentModel;

namespace BH.Engine.Representation
{
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods - Graphics                 ****/
        /***************************************************/

        public static BH.oM.Graphics.RenderMesh RenderMesh(this CompositeGeometry compositeGeometry, RenderMeshOptions renderMeshOptions = null)
        {
            if (compositeGeometry == null)
            {
                BH.Engine.Base.Compute.RecordError("Cannot compute the mesh of a null composite geometry object.");
                return null;
            }

            renderMeshOptions = renderMeshOptions ?? new RenderMeshOptions();

            List<RenderMesh> renderMeshes = new List<RenderMesh>();

            for (int i = 0; i < compositeGeometry.Elements.Count; i++)
                renderMeshes.Add(IRenderMesh(compositeGeometry.Elements[i]));

            return BH.Engine.Representation.Compute.JoinRenderMeshes(renderMeshes);
        }
    }
}


