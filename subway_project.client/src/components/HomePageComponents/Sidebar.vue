<template>
  <CategoryList />
</template>

<script>
import CategoryList from "../CategoryList.vue";
export default {
  name: "Sidebar",
  components: {
    CategoryList,
  },
  data() {
    return {
      categories: [
        { Name: "Sub", showSubCategories: false },
        { Name: "Drinks", showSubCategories: false },
        { Name: "Snacks", showSubCategories: false },
        { Name: "Desserts", showSubCategories: false },
      ],
      subCategories: [
        { Name: "Bread" },
        { Name: "Vegetables" },
        { Name: "Sauces" },
        { Name: "Cheese" },
        { Name: "Proteins" },
      ],
    };
  },
  methods: {
    toggleSubCategories(category) {
      if (category.Name === "Sub") {
        category.showSubCategories = !category.showSubCategories;
      }
    },
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
.sidenav {
}
.mainlist {
}
.bigmenuitem {
  list-style: none;
  list-style: none;
}
</style>
