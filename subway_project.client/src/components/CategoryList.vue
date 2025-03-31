<template>
  <div>
    <h1>Categories</h1>
    <ul>
      <li v-for="category in categories" :key="category.id">
        {{ category.name }}
      </li>
    </ul>
  </div>
</template>

<script>
  import { getCategories } from '../Services/CategoryService.js';

  export default {
    data() {
      return {
        categories: []
      };
    },
    async created() {
      try {
        const data = await getCategories();
        console.log(data); 
        this.categories = data;
      } catch (error) {
        console.error('Failed to load categories:', error);
      }
    }
  };
</script>

<style scoped>
</style>
