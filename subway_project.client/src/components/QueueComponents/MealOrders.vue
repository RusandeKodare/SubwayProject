<script>
  export default {
    props: {
    // Define props for list title and list items
    listTitle: {
      type: String,
      required: true
    },
    listItems: {
      type: Array,
      required: true
    }
  }
  };
</script>

<template>
  <div class="orders">
    <!-- Display the dynamic title passed via props -->
    <h2>{{ listTitle }}</h2>
    <!-- Display the list of items -->
    <ul>
      <li v-for="(item, index) in listItems" :key="index">{{ item }}</li>
    </ul>
  </div>
</template>

<style scoped>

</style>
