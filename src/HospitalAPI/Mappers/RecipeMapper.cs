using HospitalAPI.Dtos;
using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Mappers
{
    public class RecipeMapper : IGenericMapper<Recipe, RecipeDTO>
    {
        private readonly IGenericMapper<Medicine, MedicineDTO> _medicineMapper;
        private readonly IGenericMapper<Symptom, SymptomDTO> _symptomMapper;

        public RecipeMapper(IGenericMapper<Medicine, MedicineDTO> medicineMapper, IGenericMapper<Symptom, SymptomDTO> symptomMapper)
        {
            _medicineMapper = medicineMapper;
            _symptomMapper = symptomMapper;
        }

        public RecipeDTO ToDTO(Recipe recipe)
        {
            RecipeDTO recipeDTO = new RecipeDTO();
            recipeDTO.RecipeId = recipe.RecipeId;
            recipeDTO.WayOfUse = recipe.WayOfUse;
            recipeDTO.MedicineIds = recipe.MedicineIds;
            recipeDTO.Medicines = _medicineMapper.ToDTO(recipe.Medicines);
            recipeDTO.DateOfIssue = recipe.DateOfIssue;

            return recipeDTO;

        }

        public List<RecipeDTO> ToDTO(List<Recipe> recipes)
        {
            List<RecipeDTO> recipesDTOs = new List<RecipeDTO>();
            foreach (var recipe in recipes)
            {
                RecipeDTO recipeDTO = new RecipeDTO();
                recipeDTO.RecipeId = recipe.RecipeId;
                recipeDTO.WayOfUse = recipe.WayOfUse;
                recipeDTO.MedicineIds = recipe.MedicineIds;
                recipeDTO.Medicines = _medicineMapper.ToDTO(recipe.Medicines);
                recipeDTO.DateOfIssue = recipe.DateOfIssue;
                recipesDTOs.Add(recipeDTO);
            }

            return recipesDTOs;
        }

        public Recipe ToModel(RecipeDTO recipeDTO)
        {
            Recipe recipe = new Recipe();
            recipe.RecipeId = recipeDTO.RecipeId;
            recipe.WayOfUse = recipeDTO.WayOfUse;
            recipe.MedicineIds = recipeDTO.MedicineIds;
            recipe.Medicines = _medicineMapper.ToModel(recipeDTO.Medicines);
            recipe.DateOfIssue = recipeDTO.DateOfIssue;

            return recipe;
        }

        public List<Recipe> ToModel(List<RecipeDTO> recipeDTOs)
        {
            List<Recipe> recipes = new List<Recipe>();
            foreach (var recipeDTO in recipeDTOs)
            {
                Recipe recipe = new Recipe();
                recipe.RecipeId = recipeDTO.RecipeId;
                recipe.WayOfUse = recipeDTO.WayOfUse;
                recipe.MedicineIds = recipeDTO.MedicineIds;
                recipe.Medicines = _medicineMapper.ToModel(recipeDTO.Medicines);
                recipe.DateOfIssue = recipeDTO.DateOfIssue;
                recipes.Add(recipe);
            }

            return recipes;
        }
    }
}
