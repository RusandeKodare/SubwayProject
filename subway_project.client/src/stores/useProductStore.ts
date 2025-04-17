import { defineStore } from 'pinia'

export const useProductStore = defineStore('products', {
  state: () => ({
    selectedProducts: [] as object[] 
  }),
  actions: {
    addProduct(product: object) {
      this.selectedProducts.push(product)
    },
    checkState(){
      this.selectedProducts.forEach(product => {
        console.log('pinia', product)
      });
    },
    checkLocalStorage(){
      this.selectedProducts = localStorage.getItem('selectedProducts')
      this.selectedProducts = JSON.parse(this.selectedProducts)
      if(this.selectedProducts){
        this.selectedProducts.forEach(product => {
          console.log(product.name);
        });
      }
      else{
        console.log('No products in local storage');
        this.selectedProducts = []
      }

    },
    saveToLocalStorage(){
      localStorage.setItem('selectedProducts', JSON.stringify(this.selectedProducts))
    },
    removeFromLocalStorage(){
      localStorage.removeItem('selectedProducts')
    }
  }
})
