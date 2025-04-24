// import { defineStore } from 'pinia'

// export const useProductStore = defineStore('products', {
//   state: () => ({
//     selectedProducts: [] 
//   }),
//   actions: {
//     addProduct(product) {
//       this.selectedProducts.push(product)
//     },
//     checkState(){
//       this.selectedProducts.forEach(product => {
//         console.log('pinia', product)
//       });
//     },
//     checkLocalStorage() {
//       const stored = localStorage.getItem('selectedProducts')
//       if (stored) {
//         this.selectedProducts = JSON.parse(stored)
//         this.selectedProducts.forEach(product => {
//           console.log(product.name)
//         })
//       } else {
//         console.log('No products in local storage')
//         this.selectedProducts = []
//       }
//     },
//     saveToLocalStorage(){
//       localStorage.setItem('selectedProducts', JSON.stringify(this.selectedProducts))
//     },
//     removeFromLocalStorage(){
//       localStorage.removeItem('selectedProducts')
//     }
//   }
// })
