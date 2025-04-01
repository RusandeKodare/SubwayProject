<template>
  <div>
    <ul>
      <li v-for="category in categories" :key="category.id">
        <a>{{ category.name }}</a>
      </li>
    </ul>
  </div>
</template>

<script>
import { getCategories } from "../Services/CategoryService.js";

export default {
  name: "CategoryList",
  data() {
    return {
      categories: [],
    };
  },
  async created() {
    try {
      const data = await getCategories();
      console.log(data);
      this.categories = data;
    } catch (error) {
      console.error("Failed to load categories:", error);
    }
  },
};
</script>

<style scoped>
li {
  cursor: pointer;
  list-style: none;
}

a {
  display: block;
  padding: 2px;
  margin: 8px;
  color: greenyellow;
  text-shadow: 3px 3px 2px black;
  font-size: 70px;
  text-decoration: none;
}
</style>
