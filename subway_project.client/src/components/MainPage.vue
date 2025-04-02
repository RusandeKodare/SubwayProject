<script setup>
    import { ref } from "vue";

    const baseUrl = "https://localhost:7193";

    const products = ref([
        {id: 1, name: "Hello"}
    ]);

    const getProducts = async () => {
        const response = await fetch(baseUrl + "/api/products");
        const data = await response.json();
        products.value = data;
    }

</script>

<template>
    <button @click="getProducts">Click Me</button>
    <div class="products-container">
        <div v-for="p in products" :key="p.id" :id="`product-` + p.id" class="product">
            <h1>{{ p.name }}</h1>
            <p>{{ p.price }}</p>
        </div>
    </div>
</template>