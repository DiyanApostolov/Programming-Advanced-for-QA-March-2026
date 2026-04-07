import {artGallery} from '../artGallery.js'
import { expect, assert } from 'chai'

describe('artGallery', () => {
    describe('test addArtwork', () => {
        it('should throw an error if title is not a string', () => {
            expect(() => artGallery.addArtwork(42, '50 x 70', 'Picasso')).to.throw("Invalid Information!")
            expect(() => artGallery.addArtwork([], '50 x 70', 'Picasso')).to.throw("Invalid Information!")
            expect(() => artGallery.addArtwork({}, '50 x 70', 'Picasso')).to.throw("Invalid Information!")
            expect(() => artGallery.addArtwork(null, '50 x 70', 'Picasso')).to.throw("Invalid Information!")
        })
        it('should throw an error if artist is not a string', () => {
            expect(() => artGallery.addArtwork('Girl on the ball', '50 x 70', 42)).to.throw("Invalid Information!")
            expect(() => artGallery.addArtwork('Girl on the ball', '50 x 70', [])).to.throw("Invalid Information!")
            expect(() => artGallery.addArtwork('Girl on the ball', '50 x 70', {})).to.throw("Invalid Information!")
            expect(() => artGallery.addArtwork('Girl on the ball', '50 x 70', null)).to.throw("Invalid Information!")
        })
        it('should throw an error if dimension is not in valid format', () => {
            expect(() => artGallery.addArtwork('Girl on the ball', '50x70', 'Picasso')).to.throw("Invalid Dimensions!")
            expect(() => artGallery.addArtwork('Girl on the ball', 'pet x 70', 'Picasso')).to.throw("Invalid Dimensions!")
            expect(() => artGallery.addArtwork('Girl on the ball', '50x 70', 'Picasso')).to.throw("Invalid Dimensions!")
            expect(() => artGallery.addArtwork('Girl on the ball', '50 x70', 'Picasso')).to.throw("Invalid Dimensions!")
        })
        it('should throw an error if artist is not allowed', () => {
            expect(() => artGallery.addArtwork('Girl on the ball', '50 x 70', 'V.D.-Maistora')).to.throw("This artist is not allowed in the gallery!")
        })
        it('should return proper message if all parameters are valid', () => {
            let expectedMessage = `Artwork added successfully: 'Girl on the ball' by Picasso with dimensions 50 x 70.`

            expect(artGallery.addArtwork('Girl on the ball', '50 x 70', 'Picasso')).to.equal(expectedMessage)
        })
    })
    describe('test calculateCosts', () => {
        it('should throw an error if any parameter are not valid', () => {
            // test exhibitionCosts is not a number
            assert.Throw(() => artGallery.calculateCosts('invalid', 100, true), 'Invalid Information!')
            // test insuranceCosts is not a number
            assert.Throw(() => artGallery.calculateCosts(100, 'invalid', true), 'Invalid Information!')
            // test sponsor is boolean
            assert.Throw(() => artGallery.calculateCosts(100, 50, 'invalid'), 'Invalid Information!')
            // test exhibitionCosts is a negative number
            assert.Throw(() => artGallery.calculateCosts(-50, 100, true), 'Invalid Information!')
            // test insuranceCosts is a negative number
            assert.Throw(() => artGallery.calculateCosts(100, -50, true), 'Invalid Information!')
        })
        it('correct calculations with a sponsor', ()=> {
            let expectedMessage = "Exhibition and insurance costs are 225$, reduced by 10% with the help of a donation from your sponsor."

            assert.equal(artGallery.calculateCosts(200, 50, true), expectedMessage)   
        })
        it('correct calculations without a sponsor', ()=> {
             let expectedMessage = "Exhibition and insurance costs are 250$."

             assert.equal(artGallery.calculateCosts(200, 50, false), expectedMessage)
        })
    })
    describe('test organizeExhibits', () => {
        it('should throw an error if any parameter are not valid', () => {
            expect(() => artGallery.organizeExhibits('invalid', 10)).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(10,'invalid')).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(10, -10)).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(-10, 10)).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(0, 10)).to.throw("Invalid Information!")
            expect(() => artGallery.organizeExhibits(10, 0)).to.throw("Invalid Information!")
        })
        it('should return proper message if artworksPerSpace is lower than five', () => {
            let expectedMessage = `There are only 3 artworks in each display space, you can add more artworks.`
            
            expect(artGallery.organizeExhibits(20, 6)).to.equal(expectedMessage)
        })
        it('should return proper message if artworksPerSpace is greater or equal to five', () => {
            let expectedMessage = `You have 7 display spaces with 6 artworks in each space.`

            expect(artGallery.organizeExhibits(47, 7)).to.equal(expectedMessage) // greater than 5

            expect(artGallery.organizeExhibits(37, 7)).to.equal(`You have 7 display spaces with 5 artworks in each space.`)
        })
    })
})